<template>
  <main class="profile-keep col-3">
    <a href="" data-toggle="modal" :data-target="keepId">
      <div
        id="keep"
        class="card neu-styling m-2 d-flex flex-wrap justify-content-end justify-content-between align-items-between"
        v-bind:style="{ backgroundImage: 'url(' + this.keep.img + ')' }"
      >
        <div class="">
          <h4>
            {{ keep.name }}
          </h4>
        </div>
      </div>
    </a>
    <section id="keep-modal">
      <details-modal :id="modalId">
        <template v-slot:body>
          <div class="row modal-width">
            <div class="col-4">
              <img :src="keep.img" class="card-img" />
            </div>
            <div class="col-8">
              <div class="card-body">
                <p>
                  Shares:{{ keep.shares }},Views:{{ keep.views }},Keeps:{{
                    keep.keeps
                  }}
                </p>
                <button @click="deleteVaultKeep(keep.vaultId)">delete</button>
                <div>
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
                </div>
                <hr />
                <h5 class="card-title">{{ keep.name }}</h5>
                <br />
                <p class="card-text">{{ keep.description }}</p>
                <hr />
                <p class="card-text">{{ keep.creator.name }}</p>
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
  },
  methods: {
    deleteVaultKeep(id) {
      this.$store.dispatch("delete", {
        deletePath: "vaultkeeps/" + this.keep.vaultId,
        resource: "vaultKeeps",
        path: "vaults/" + this.$route.params.Id + "/keeps",
      });
      $(".modal-backdrop").hide();
      $(".modal").hide();
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
.modal-img {
  width: 40vw;
}
.modal-width {
  width: 70vw;
}
.neu-styling {
  box-shadow: 10px 10px 20px #acacad;
  /* border: 1px solid rgba(255, 255, 255, 0.2); */
  border-radius: 12px;
  min-height: 50vh;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}
/* .keep {
  transition: 0.5s ease;
}
.keep:hover {
  transform: scale(1.05);
} */
</style>
