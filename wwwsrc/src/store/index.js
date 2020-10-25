import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    activeProfile: {},
    activeVault: {},
    keeps: [],
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
        commit("setResource", { data: res.data, resource: payload.resource });
      } catch (error) {
        console.error(error);
      }
    },
    async createBug({ dispatch }, payload) {
      try {
        let res = await api.post(payload.path, payload.data);
        dispatch("getResource", {
          path: "bugs/" + res.data.id,
          resource: payload.resource,
        });
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
        await api.delete(payload.deletePath);
        dispatch("getResource", {
          path: payload.path,
          resource: payload.resource,
        });
      } catch (error) {
        console.error(error);
      }
    },
    //!SECTION Array Methods
  },
});
