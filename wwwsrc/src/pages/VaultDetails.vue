<template>
  <main class="vault-details container-fluid">
    <section class="row">
      <article id="vault-header" class="col-12">
        <h1>{{ vault.name }}</h1>
        <p>Keeps: {{ keeps.length }}</p>
      </article>
    </section>
    <section class="row d-flex justify-content-center">
      <profile-keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </section>
  </main>
</template>

<script>
import ProfileKeep from "../components/ProfileKeep.vue";
export default {
  name: "vault-details",
  mounted() {
    this.$store.dispatch("getResource", {
      path: "vaults/" + this.$route.params.Id,
      resource: "activeVault",
    });
    this.$store.dispatch("getResource", {
      path: "vaults/" + this.$route.params.Id + "/keeps",
      resource: "vaultKeeps",
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
  },
  watch: {
    profile: function(userProfile) {
      if (userProfile.picture) {
      }
    },
  },
  methods: {},
  components: {
    ProfileKeep,
  },
};
</script>

<style scoped></style>
