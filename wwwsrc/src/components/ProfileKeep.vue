<template>
  <main class="profile-keep">
    <section
      class="zoom-in m-2 card keep-body neu-styling"
      data-toggle="modal"
      :data-target="keepId"
      @click="addView"
    >
      <img class="card-img-top keep-img" :src="this.keep.img" alt="" />
      <div class="bottom-left">
        <h4 class="shadow">{{ keep.name }}</h4>
      </div>
      <div class="bottom-right"></div>
    </section>
    <section id="profile-keep-modal">
      <details-modal :id="modalId">
        <template v-slot:body>
          <div class="row modal-width">
            <div
              class="text-center flex-wrap align-items-center modal-img col-7"
            >
              <img :src="keep.img" class="m-1 card-img" />
            </div>
            <div class="col-5">
              <div class="card-body">
                <div id="stat-tracking" class="text-center">
                  <p class="text-right">
                    <i
                      class="fa fa-times exit-icon pointer"
                      aria-hidden="true"
                      data-dismiss="modal"
                    ></i>
                  </p>
                  <p>
                    <span>
                      <i
                        class="fa fa-eye m-1 counter-icon"
                        aria-hidden="true"
                      ></i
                      >{{ keep.views }}
                    </span>

                    <span class="mx-5">
                      <i
                        class="fa fa-hdd-o m-1 counter-icon"
                        aria-hidden="true"
                      ></i
                      >{{ keep.keeps }}
                    </span>

                    <span class="mx-2"
                      ><i
                        class="fa fa-share-alt m-1 counter-icon"
                        aria-hidden="true"
                      ></i
                      >{{ keep.shares }}</span
                    >
                  </p>
                </div>
                <div id="modal-title">
                  <h2 class="card-title">{{ keep.name }}</h2>
                  <hr />
                </div>
                <div id="modal-description">
                  <br />
                  <p class="card-text">{{ keep.description }}</p>
                </div>
                <div
                  class="d-flex justify-content-between"
                  id="footer-functions"
                >
                  <hr />
                  <div class="dropdown">
                    <a
                      class="btn btn-secondary dropdown-toggle"
                      href="#"
                      role="button"
                      id="dropdownMenuLink"
                      data-toggle="dropdown"
                      aria-haspopup="true"
                      aria-expanded="false"
                    >
                      Add to Vault
                    </a>

                    <div
                      class="dropdown-menu"
                      aria-labelledby="dropdownMenuLink"
                    >
                      <a
                        href="#"
                        @click="createVaultKeep(vault.id)"
                        data-dismiss="modal"
                        class="dropdown-item"
                        :value="vault.id"
                        v-for="vault in vaults"
                        :key="vault.id"
                        >{{ vault.name }}</a
                      >
                    </div>
                  </div>
                  <i
                    v-if="isCreator"
                    @click="deleteKeep(keep.id)"
                    data-dismiss="modal"
                    class="fa fa-trash-o trash-icon pointer mx-5"
                    aria-hidden="true"
                  ></i>
                  <p class="">{{ keep.creator.name }}</p>
                  <img class="creator-img" :src="keep.creator.picture" alt="" />
                </div>
              </div>
            </div>
          </div>
        </template>
      </details-modal>
    </section>
  </main>
</template>

<script>
import DetailsModal from "../components/DetailsModal.vue";
export default {
  name: "profile-keep",
  data() {
    return {
      newVaultKeep: {},
    };
  },
  mounted() {},
  props: {
    keep: {},
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    keepId() {
      return "#a-" + this.keep.id.toString();
    },
    modalId() {
      return "a-" + this.keep.id.toString();
    },
    activeProfile() {
      return this.$store.state.activeProfile;
    },
    isCreator() {
      return this.$store.state.profile.id == this.keep.creatorId;
    },
  },
  methods: {
    addView() {
      this.$store.dispatch("getResource", {
        path: "keeps/" + this.keep.id,
        resource: "activeKeep",
      });
      this.$store.dispatch("getResource", {
        path: "profiles/" + this.activeProfile.id + "/keeps",
        resource: "keeps",
      });
    },
    deleteKeep(id) {
      this.$store.dispatch("delete", {
        deletePath: "keeps/" + this.keep.id,
        resource: "keeps",
        path: "keeps",
      });
      $(".modal-backdrop").hide();
      $(".modal").hide();
    },
    createVaultKeep(id) {
      this.newVaultKeep.vaultId = id;
      this.newVaultKeep.keepId = this.keep.id;
      this.$store.dispatch("create", {
        getPath: "vaults/" + id + "/keeps",
        path: "vaultkeeps",
        resource: "vaultKeeps",
        data: this.newVaultKeep,
      });
    },
  },
  components: {
    DetailsModal,
  },
};
</script>

<style scoped></style>
