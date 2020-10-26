<template>
  <main class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
      <div class="container-fluid d-flex justify-content-center modal-content">
        <div class="row">
          <slot name="body"></slot>
        </div>
      </div>
    </div>
  </main>
</template>

<script>
export default {
  name: "detail-modal",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {},
};
</script>

<style scoped></style>
