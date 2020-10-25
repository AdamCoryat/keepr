<template>
  <section class="keep col-3">
    <a href="" data-toggle="modal" :data-target="keepId">
      <div class="card m-2">
        <img class="card-img-top" :src="keep.img" alt="" />
        <div class="card-body">
          <h4 class="card-title">{{ keep.name }}</h4>
          <button @click="deleteKeep(keep.id)">delete</button>
          <img :src="keep.creator.picture" />
        </div>
      </div>
    </a>
    <section id="keep-modal">
      <details-modal :id="modalId">
        <template v-slot:body>
          <div class="row modal-width">
            <div class="col-4">
              <img :src="keep.img" class="card-img" />
            </div>
            <div class="col-8">
              <div class="card-body">
                <p>
                  Shares:{{ keep.shares }},Views:{{ keep.views }},Keeps:{{
                    keep.keeps
                  }}
                </p>
                <hr />
                <h5 class="card-title">{{ keep.name }}</h5>
                <br />
                <p class="card-text">{{ keep.description }}</p>
                <hr />

                <p class="card-text">{{ keep.creator.name }}</p>
              </div>
            </div>
          </div>
        </template>
      </details-modal>
    </section>
  </section>
</template>

<script>
import DetailsModal from "../components/DetailsModal.vue";
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
    DetailsModal,
  },
};
</script>

<style scoped>
.modal-img {
  width: 40vw;
}
.modal-width {
  width: 70vw;
}
</style>
