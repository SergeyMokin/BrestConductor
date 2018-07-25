import Vue from 'vue';
import Vuex from 'vuex';
import api from '../api/api'

Vue.use(Vuex);

const state = {
    posts: []
};

const getters = {
    posts: state => state.posts
};


const mutations = {
    getPosts(state, posts)
    {
      state.posts = posts;
    }
    , createPost(state, post)
    {
        state.posts.unshift(post);
    }
    , editPost(state, post)
    {
        console.log('successful edit')
        console.log(post);
    }
};

const actions = {
    getPosts: ({ commit }) => {
      api.getPosts().then(posts => {
        commit('getPosts', posts);
      })
      .catch(e => {console.log(e)});
    }
    , createPost: ({ commit }, post) => {
      api
      .createPost(post)
      .then(data => commit('createPost', post))
      .catch(e => console.log(e));
    }
    , editPost: ({commit}, post) => {
        api.editPost(post)
        .then(data => commit('editPost', post))
        .catch(e => console.log(e));
    }
};

export default new Vuex.Store({
    state
    , getters
    , mutations
    , actions
});