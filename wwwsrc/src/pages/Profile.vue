<template>
  <main class="profile container-fluid">
    <section class="row">
      <article id="profile-stats" class="col-4"></article>
      <article id="profile-info" class="col-4 text-center">
        <p>{{ profile.name }}</p>
        <p>{{ profile.email }}</p>
        <img :src="profile.picture" alt="" />
      </article>
      <article id="profile-tools" class="col-4">
        <button
          type="button"
          class="btn btn-danger mx-1"
          data-toggle="modal"
          data-target="#keepCreate"
        >
          Create Keep
        </button>
        <button type="button" class="button btn-primary">Create Vault</button>
      </article>
    </section>
    <section id="modals">
      <form-modal id="keepCreate">
        <template v-slot:header>
          <h5>Create New Keep</h5>
        </template>
        <template v-slot:body>
          <div class="row text-center d-flex">
            <div class="col-12">
              <form @submit.prevent="createKeep" class="m-2">
                <input
                  type="text"
                  placeholder="Name"
                  v-model="newKeep.name"
                  required
                />
                <br />
                <input
                  type="text"
                  placeholder="Description"
                  v-model="newKeep.description"
                  required
                  class="text-light"
                />
                <br />
                <input
                  type="url"
                  placeholder="Image"
                  v-model="newKeep.img"
                  required
                  class="text-light"
                />
              </form>
            </div>
            <div class="col-12">
              <button class="btn btn-primary" type="submit" @click="createKeep">
                Create
              </button>
            </div>
          </div>
        </template>
      </form-modal>
    </section>
  </main>
</template>

<script>
import FormModal from "../components/FormModal.vue";
export default {
  name: "profile",
  mounted() {},
  data() {
    return {
      newKeep: {},
    };
  },
  computed: {
    profile() {
      return this.$store.state.profile;
    },
  },
  methods: {
    createKeep() {
      this.$store.dispatch("create", {
        getPath: "keeps",
        path: "keeps",
        resource: "keeps",
        data: this.newKeep,
      });
      (this.newKeep = {}), $(".modal-backdrop").hide();
      $(".modal").hide();
    },
  },
  components: {
    FormModal,
  },
};
</script>

<style scoped></style>
