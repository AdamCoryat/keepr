<template>
  <main class="vault-details container-fluid">
    <section v-if="vault.name" class="row">
      <article id="vault-header" class="col-12">
        <h1>{{ vault.name }}</h1>
        <p>Keeps: {{ keeps.length }}</p>
        <button
          v-if="isCreator"
          type="button"
          class="btn btn-danger"
          @click="deleteVault(vault.id)"
        >
          delete
        </button>
      </article>
    </section>
    <section class="row d-flex justify-content-center">
      <vault-keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </section>
    <section class="row" v-if="!vault.name" id="loading-screen">
      <h1>loading...</h1>
    </section>
  </main>
</template>

<script>
import VaultKeep from "../components/VaultKeep.vue";
export default {
  name: "vault-details",
  mounted() {
    this.$store.dispatch("getResource", {
      path: "vaults/" + this.$route.params.Id + "/keeps",
      resource: "vaultKeeps",
    });
    this.$store.dispatch("getResource", {
      path: "vaults/" + this.$route.params.Id,
      resource: "activeVault",
    });
    this.$store.dispatch("getResource", {
      path: "profiles/" + this.profile.id + "/vaults",
      resource: "vaults",
    });
  },

  data() {
    return {};
  },
  computed: {
    profile() {
      return this.$store.state.profile;
    },
    keeps() {
      return this.$store.state.vaultKeeps;
    },
    vault() {
      return this.$store.state.activeVault;
    },
    isCreator() {
      return this.$store.state.profile.id == this.vault.creatorId;
    },
  },
  watch: {
    profile: function(userProfile) {
      if (userProfile.picture) {
        this.$store.dispatch("getResource", {
          path: "vaults/" + this.$route.params.Id + "/keeps",
          resource: "vaultKeeps",
        });
        this.$store.dispatch("getResource", {
          path: "vaults/" + this.$route.params.Id,
          resource: "activeVault",
        });
        this.$store.dispatch("getResource", {
          path: "profiles/" + this.profile.Id + "/vaults",
          resource: "vaults",
        });
      }
    },
  },
  methods: {
    deleteVault(id) {
      this.$store.dispatch("delete", {
        deletePath: "vaults/" + this.vault.id,
        resource: "vaults",
        path: "profiles/" + this.$route.params.Id + "/vaults",
      });
    },
  },
  components: {
    VaultKeep,
  },
};
</script>

<style scoped></style>
