<template>
  <main class="keep">
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
      <div class="bottom-right">
        <a v-on:click.stop.prevent="viewProfile">
          <i
            class="fa fa-user-circle-o pointer user-icon"
            aria-hidden="true"
          ></i
        ></a>
      </div>
    </section>
    <section id="keep-modal">
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
                <div id="stat-tracking">
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
                  <select
                    v-model="newVaultKeep.vaultId"
                    @change="createVaultKeep()"
                    class="custom-select"
                  >
                    <option
                      :value="vault.id"
                      v-for="vault in vaults"
                      :key="vault.id"
                      >{{ vault.name }}</option
                    >
                  </select>
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
                      @change="createVaultKeep()"
                    >
                      <a
                        class="dropdown-item"
                        :value="vault.id"
                        v-for="vault in vaults"
                        :key="vault.id"
                        >{{ vault.name }}</a
                      >
                    </div>
                  </div>
                  <i
                    @click="deleteKeep(keep.id)"
                    data-dismiss="modal"
                    class="fa fa-trash-o trash-icon pointer mx-5"
                    aria-hidden="true"
                  ></i>
                  <p class="">{{ keep.creator.name }}</p>
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
  name: "keep",
  data() {
    return {
      newVaultKeep: {},
      editVault: {},
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
  },
  methods: {
    addView() {
      this.keep.views++;
      this.$store.dispatch("edit", {
        getPath: "keeps",
        path: "keeps/" + this.keep.id,
        data: this.keep,
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
    viewProfile() {
      this.$router.push({
        name: "Profile",
        params: { Id: this.keep.creator.id },
      });
    },
    createVaultKeep() {
      this.newVaultKeep.keepId = this.keep.id;
      this.$store.dispatch("create", {
        getPath: "vaults/" + this.newVaultKeep.vaultId + "/keeps",
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

<style scoped>
#modal-description {
  min-height: 30vh;
}
#footer-functions {
  position: absolute;
  bottom: 10px;
}
.modal-img {
  width: 40vw;
}
.modal-width {
  width: 70vw;
}

.neu-styling {
  box-shadow: 10px 10px 20px #acacad;
}
.user-icon {
  color: rgb(156, 243, 236);
  font-size: 2.5em;
}
.trash-icon {
  color: grey;
  font-size: 2.5em;
}
.keep-img {
  border-radius: 12px;
}
.keep-body {
  max-width: 30vw;
  position: relative;
  text-align: center;
  color: white;
  border-radius: 12px;
}
.bottom-left {
  position: absolute;
  bottom: 8px;
  left: 16px;
}
.bottom-right {
  position: absolute;
  bottom: 8px;
  right: 16px;
}
.counter-icon {
  color: rgb(156, 243, 236);
  font-size: 1.5em;
}
.exit-icon {
  color: red;
  font-size: 1.5em;
}
</style>
