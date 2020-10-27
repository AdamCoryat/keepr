<template>
  <main class="profile container-fluid">
    <div v-if="profile.name">
      <section class="row">
        <article id="profile-picture" class="col-2 text-center">
          <img class="m-2" :src="profile.picture" alt="" />
        </article>
        <article id="profile-info" class="col-10 text-left">
          <div>
            <h1>{{ profile.name }}</h1>
            <h5>Vaults: {{ vaults.length }}</h5>
            <h5>Keeps:{{ keeps.length }}</h5>
          </div>
        </article>
      </section>

      <section id="profile-vaults" class="row">
        <article class="col-12">
          <h3>
            Vaults
            <i
              class="fa fa-plus pointer"
              data-toggle="modal"
              data-target="#vaultCreate"
            ></i>
          </h3>
        </article>
        <article class="row">
          <vault v-for="vault in vaults" :key="vault.id" :vault="vault" />
        </article>
      </section>

      <section id="profile-keeps" class="row">
        <article class="col-12">
          <h3>
            Keeps
            <i
              class="fa fa-plus pointer"
              data-toggle="modal"
              data-target="#keepCreate"
            ></i>
          </h3>
        </article>
        <article class="card-columns">
          <profile-keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
        </article>
      </section>
    </div>
    <section v-if="!profile.name" id="loading-screen">
      <h1>Loading...</h1>
    </section>

    <section id="modals">
      <form-modal id="vaultCreate">
        <template v-slot:header>
          <h5>Create New Vault</h5>
        </template>
        <template v-slot:body>
          <div class="row text-center d-flex">
            <div class="col-12">
              <form @submit.prevent="createVault" class="m-2">
                <input
                  type="text"
                  placeholder="Name"
                  v-model="newVault.name"
                  required
                />
                <br />
                <input
                  type="text"
                  placeholder="Description"
                  v-model="newVault.description"
                  required
                />
                <br />
                <input type="checkbox" v-model="newVault.isPrivate" required />
              </form>
            </div>
            <div class="col-12">
              <button
                class="btn btn-primary"
                type="submit"
                @click="createVault"
                data-dismiss="modal"
              >
                Create
              </button>
            </div>
          </div>
        </template>
      </form-modal>
      <form-modal id="keepCreate">
        <template v-slot:header>
          <h5>Create New Keep</h5>
        </template>
        <template v-slot:body>
          <div class="row text-center d-flex">
            <div class="col-12">
              <form @submit.prevent="createKeep" class="m-2">
                <input
                  type="text"
                  placeholder="Name"
                  v-model="newKeep.name"
                  required
                />
                <br />
                <input
                  type="text"
                  placeholder="Description"
                  v-model="newKeep.description"
                  required
                />
                <br />
                <input
                  type="url"
                  placeholder="Image"
                  v-model="newKeep.img"
                  required
                />
              </form>
            </div>
            <div class="col-12">
              <button
                class="btn btn-primary"
                type="submit"
                @click="createKeep"
                data-dismiss="modal"
              >
                Create
              </button>
            </div>
          </div>
        </template>
      </form-modal>
    </section>
  </main>
</template>

<script>
import FormModal from "../components/FormModal.vue";
import Vault from "../components/Vault.vue";
import ProfileKeep from "../components/ProfileKeep.vue";
export default {
  name: "profile",
  mounted() {
    this.$store.dispatch("getResource", {
      path: "profiles/" + this.$route.params.Id,
      resource: "activeProfile",
    });
    this.$store.dispatch("getResource", {
      path: "profiles/" + this.$route.params.Id + "/vaults",
      resource: "vaults",
    });
    this.$store.dispatch("getResource", {
      path: "profiles/" + this.$route.params.Id + "/keeps",
      resource: "keeps",
    });
  },
  data() {
    return {
      newKeep: {},
      newVault: {},
    };
  },
  computed: {
    user() {
      return this.$store.state.profile;
    },
    profile() {
      return this.$store.state.activeProfile;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    createKeep() {
      this.$store.dispatch("create", {
        getPath: "profiles/" + this.$route.params.Id + "/keeps",
        path: "keeps",
        resource: "keeps",
        data: this.newKeep,
      });
      (this.newKeep = {}), $(".modal-backdrop").hide();
      $(".modal").hide();
    },
    createVault() {
      this.$store.dispatch("create", {
        getPath: "profiles/" + this.$route.params.Id + "/vaults",
        path: "vaults",
        resource: "vaults",
        data: this.newVault,
      });
      (this.newVault = {}), $(".modal-backdrop").hide();
      $(".modal").hide();
    },
  },
  components: {
    FormModal,
    Vault,
    ProfileKeep,
  },
};
</script>

<style scoped></style>
