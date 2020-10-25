import Vue from "vue";
import VueRouter from "vue-router";
// @ts-ignore
import Home from "../pages/Home.vue";
// @ts-ignore
import Profile from "../pages/Profile.vue";
// @ts-ignore
import Vault from "../pages/VaultDetails.vue";
Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/profile/:Id",
    name: "Profile",
    component: Profile,
  },
  {
    path: "/vault/:Id",
    name: "Vault",
    component: Vault,
  },
];

const router = new VueRouter({
  routes,
});

export default router;
