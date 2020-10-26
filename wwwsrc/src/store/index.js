import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";
import ns from "../services/NotificationService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    activeProfile: {},
    activeVault: {},
    keeps: [],
    vaultKeeps: [],
    vaults: [],
    profileVaults: [],
    activeKeep: {},
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setResource(state, payload) {
      state[payload.resource] = payload.data;
    },
  },
  actions: {
    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    //SECTION Array Methods
    async getResource({ commit }, payload) {
      try {
        let res = await api.get(payload.path);
        console.log(res.data);
        commit("setResource", { data: res.data, resource: payload.resource });
      } catch (error) {
        console.error(error);
      }
    },
    async create({ dispatch }, payload) {
      try {
        let res = await api.post(payload.path, payload.data);
        dispatch("getResource", {
          path: payload.getPath,
          resource: payload.resource,
        });
        ns.toast("Created!", 2000, "success");
      } catch (error) {
        console.error(error);
      }
    },
    async edit({ dispatch }, payload) {
      try {
        await api.put(payload.path, payload.data);
        dispatch("getResource", {
          path: payload.getPath,
          resource: payload.resource,
        });
      } catch (error) {
        console.error(error);
      }
    },
    async delete({ dispatch }, payload) {
      try {
        if (await ns.confirmAction("do you want to delete?"))
          await api.delete(payload.deletePath);
        dispatch("getResource", {
          path: payload.path,
          resource: payload.resource,
        });
        ns.toast("Deleted!", 2000, "success");
      } catch (error) {
        console.error(error);
      }
    },
    //!SECTION Array Methods
  },
});
