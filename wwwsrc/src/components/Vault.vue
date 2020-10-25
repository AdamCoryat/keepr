<template>
  <div class="vault  col-3">
    <router-link
      class="card vault-width"
      :to="{ name: 'Vault', params: { Id: vault.id } }"
    >
      <div class="card-body">
        <h4 class="card-title">{{ vault.name }}</h4>
        <p class="card-text">{{ vault.description }}</p>
        <button
          type="button"
          class="btn btn-danger"
          @click="deleteVault(vault.id)"
        >
          delete
        </button>
      </div>
    </router-link>
  </div>
</template>

<script>
export default {
  name: "vault",
  props: {
    vault: {},
  },
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteVault(id) {
      this.$store.dispatch("delete", {
        deletePath: "vaults/" + this.vault.id,
        resource: "vaults",
        path: "profiles/" + this.$route.params.Id + "/vaults",
      });
    },
  },
  components: {},
};
</script>

<style scoped>
.vault-width {
  min-width: 25vw;
}
</style>
