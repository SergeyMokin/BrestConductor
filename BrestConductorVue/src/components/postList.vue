<template>
    <div class="list">
      <p v-show = "isHidden" style = "margin: 1px"><img src="../assets/search.png" width="25" height="25" v-on:click = "isHidden = false" style = "cursor: pointer;"></p>
      <p v-show = "!isHidden" style = "margin: 1px"><img src="../assets/cross.png" width="25" height="25" v-on:click = "isHidden = true; search = '' " style = "cursor: pointer;"></p>
      <input v-show = "!isHidden" type = "text" v-model="search" class = "searchForm" placeholder = "Search...">
      <post v-for = 'post in filteredPosts' :post.sync = 'post' :key = 'post.id'/>
    </div>
</template>

<script>
import post from './post';

export default {
  data(){
    return {
      search: ''
      , isHidden: true
    }
  }
  , components: {
    post
  }
  , computed: 
  {
    filteredPosts()
    {
      var self = this;
      return this.$store.getters.posts.filter(function(post) {
                return post.Message.toLowerCase().indexOf(self.search.toLowerCase()) > -1
            })
    }
  }
  , created: function()
  {
    this.$store.dispatch('getPosts');
  }
};
</script>
