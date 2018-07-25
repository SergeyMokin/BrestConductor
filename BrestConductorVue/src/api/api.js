import axios from 'axios';

export default {
  getPosts() {
    return axios.get('http://localhost:63611/api/posts')
    .then(response => response.data)
    .catch(error => error);
  },
  createPost(post) {
    return axios.post('http://localhost:63611/api/posts', post)
    .then(response => response.data)
    .catch(error => error);
  },
  editPost(post) {
    return axios.put('http://localhost:63611/api/posts', post)
    .then(response => response.data)
    .catch(error => error);
  },
};



