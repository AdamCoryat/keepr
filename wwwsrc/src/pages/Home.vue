<template>
  <main class="home container-fluid">
    <section class="row">
      <keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </section>
    <section id="keep-modals"></section>
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
    keeps() {
      return this.$store.state.keeps;
    },
  },
  methods: {},
  components: {
    Keep,
    DetailsModal,
  },
};
</script>

<style scoped></style>
