<template>
  <main class="vault-details container-fluid">
    <section class="row">
      <article id="vault-header" class="col-12"></article>
    </section>
  </main>
</template>

<script>
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
  computed: {},
  methods: {},
  components: {},
};
</script>

<style scoped></style>
