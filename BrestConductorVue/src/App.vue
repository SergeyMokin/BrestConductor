<template>
  <div id="app">
    <createPost/> 
    <postList/>
  </div>
</template>

<script>
import postList from '../src/components/postList';
import createPost from '../src/components/createPost';

export default {
  name: 'app'
  , components: {
    postList
    , createPost
  }
  , updated: function () {
  this.$nextTick(function () {
    
  })
}
}
</script>

<style>
#app {
  width: 100%;
  text-align: center;
  color: #2c3e50;
}
h1, h2, h3 {
  font-weight: normal;
  color:#2c3e50;
}
</style>
