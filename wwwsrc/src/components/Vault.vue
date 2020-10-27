<template>
  <div class="col-2">
    <router-link :to="{ name: 'Vault', params: { Id: vault.id } }">
      <div class="m-2 vault card neu-styling">
        <div class="card-body text-center">
          <h4 class="card-title">{{ vault.name }}</h4>
        </div>
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
  methods: {},
  components: {},
};
</script>

<style scoped>
.vault {
  border-radius: 12px;
}
.vault-width {
  min-width: 25vw;
}
.img-size {
  width: 20vw;
}
</style>
