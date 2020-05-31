<script>
import Vue from "vue";

export default {
  makeToast(text, variant = null) {
    const vm = new Vue();

    vm.$bvToast.toast(text, {
      variant: variant,
      solid: true,
      noCloseButton: true,
      autoHideDelay: 1000
      
    });
  }
};
</script>