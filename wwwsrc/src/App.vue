<template>
  <div class="bg-clr" id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
import { setBearer } from "./services/AxiosService";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    if (this.$auth.isAuthenticated) {
      setBearer(this.$auth.bearer);
      this.$store.dispatch("getProfile");
      //NOTE if you want to do something everytime the user logs in, do so here
    }
  },
  components: {
    Navbar,
  },
};
</script>
<style lang="scss">
@import "./assets/_variables.scss";
@import "bootstrap";
@import "./assets/_overrides.scss";
.bg-clr {
  background-color: #f7f7f8;
  // background-image: linear-gradient(135deg, #fdfdfd 0%, #c6c9c9 100%);
}
</style>
