<template>
  <main class="home container-fluid">
    <div class="row justify-content-center">
      <div class="card-columns cards text-center">
        <keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
      </div>
    </div>
  </main>
</template>

<script>
import Keep from "../components/Keep.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getResource", {
      path: "keeps",
      resource: "keeps",
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
      return this.$store.state.keeps;
    },
  },
  watch: {
    profile: function(userProfile) {
      if (userProfile.picture) {
        this.$store.dispatch("getResource", {
          path: "profiles/" + this.profile.id + "/vaults",
          resource: "vaults",
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

<style scoped>
.home {
  height: 100vh;
}
.cards {
  display: inline-block;
}
</style>
