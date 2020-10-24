<template>
  <section class="keep col-3">
    <a href="" data-toggle="modal" :data-target="keepId">
      <div class="card m-2">
        <img class="card-img-top" :src="keep.img" alt="" />
        <div class="card-body">
          <h4 class="card-title">{{ keep.name }}</h4>
          <p class="card-text">{{ keep.creator.email }}</p>
          <button @click="deleteKeep(keep.id)">delete</button>
        </div>
      </div>
    </a>
    <section id="keep-modal">
      <form-modal :id="modalId">
        <template v-slot:header>
          <div class="row">
            <div class="col-12">
              <h1>{{ keep.name }}</h1>
            </div>
          </div>
        </template>
        <template v-slot:body>
          <div class="card col-12">
            <img class="card-img-top" :src="keep.img" alt="" />
            <div class="card-body">
              <h4 class="card-title">{{ keep.name }}</h4>

              <p class="card-text">Creator:{{ keep.creator.email }}</p>
              <p class="card-text">Shares:{{ keep.shares }}</p>
              <p class="card-text">Keeps:{{ keep.keeps }}</p>
              <p class="card-text">Views:{{ keep.views }}</p>
              <button @click="deleteKeep(keep.id)">delete</button>
            </div>
          </div>
        </template>
      </form-modal>
    </section>
  </section>
</template>

<script>
import FormModal from "../components/FormModal.vue";
export default {
  name: "keep",
  data() {
    return {};
  },
  mounted() {},
  props: {
    keep: {},
  },
  computed: {
    keepId() {
      return "#a-" + this.keep.id.toString();
    },
    modalId() {
      return "a-" + this.keep.id.toString();
    },
  },
  methods: {
    deleteKeep(id) {
      this.$store.dispatch("delete", {
        deletePath: "keeps/" + this.keep.id,
        resource: "keeps",
        path: "keeps",
      });
    },
  },
  components: {
    FormModal,
  },
};
</script>

<style scoped></style>
