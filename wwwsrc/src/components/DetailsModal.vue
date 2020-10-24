<template>
  <section id="details-modal" class="details-modal">
    <div class="row modal fade" tabindex="-1" role="dialog">
      <div class="modal-dialog" role="document">
        <div class="modal-content bg-primary border-secondary">
          <div class=" text-light modal-header text-center">
            <slot name="header"></slot>
            <i
              type="button"
              class="fa fa-times  text-warning"
              data-dismiss="modal"
              aria-label="Close"
            >
            </i>
          </div>
          <slot name="body"></slot>
          <div class="modal-footer"></div>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
export default {
  name: "details-modal",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {},
};
</script>

<style scoped></style>
