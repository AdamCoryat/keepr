<template>
  <main class="modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="container modal-content">
        <div class="modal-header text-center">
          <slot name="header"></slot>
          <i
            type="button"
            class="fa fa-times text-warning"
            data-dismiss="modal"
            aria-label="Close"
          >
          </i>
        </div>
        <div class="row">
          <slot name="body"></slot>
        </div>
        <div class="modal-footer"></div>
      </div>
    </div>
  </main>
</template>

<script>
export default {
  name: "form-modal",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {},
};
</script>

<style scoped></style>
