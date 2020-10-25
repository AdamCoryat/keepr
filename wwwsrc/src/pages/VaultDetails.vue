<template>
  <main class="vault-details container-fluid">
    <section class="row">
      <article id="vault-header" class="col-12">
        <h1>{{ vault.name }}</h1>
        <p>Keeps: {{ keeps.length }}</p>
      </article>
    </section>
    <section>
      <keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </section>
  </main>
</template>

<script>
import Keep from "../components/Keep.vue";
export default {
  name: "vault-details",
  mounted() {
    this.$store.dispatch("getResource", {
      path: "vaults/" + this.$route.params.Id,
      resource: "activeVault",
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
        this.$store.dispatch("getResource", {
          path: "vaults/" + this.$route.params.Id + "/keeps",
          resource: "vaultKeeps",
        });
      }
    },
  },
  methods: {},
  components: {
    Keep,
  },
};
</script>

<style scoped></style>
