<script setup lang="ts">
  import { ref } from 'vue';
  const model = ref({
    username: "",
    password: ""
  })

  function login()
  {
    console.log(model.value)
  }
</script>

<template>
  <div>
    <div>
      <form @submit.prevent="login">
        <div class="form-group">
          <input type="text" class="form-input" v-model="model.username">
        </div>
        <div class="form-group">
          <input type="password" class="form-input" autocomplete="off" v-model="model.password">
        </div>
        <button type="submit" class="btn btn-primary">Вход</button>
      </form>
    </div>
  </div>
</template>

<style scoped>

</style>