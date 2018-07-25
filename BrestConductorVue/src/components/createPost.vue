<template>
  <div style = "margin-top: 15px;">
    <img src="../assets/plusicon.png" height="50px" width="50px" v-on:click="openForm" v-show="!isCreating" style="cursor: pointer; margin-bottom: 20px;">
    <div class = "form" v-show="isCreating">
      <div>
        <div>
          <div>
            <h3>Text of message</h3>
            <textarea class = "inputText" v-model="message"/>
          </div>
          <div>
            <img src="../assets/confirm.png" height="50px" width="50px"  v-on:click="sendForm" style="cursor: pointer; padding-right: 50px;">
            <img src="../assets/cross.png" height="40px" width="40px"  v-on:click="closeForm" style="cursor: pointer; padding-bottom: 5px">
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import api from '../api/api';

export default {
  data() {
    return {
      message: '',
      isCreating: false,
    };
  },
  methods: {
    openForm() {
      this.isCreating = true;
    }
    , closeForm() {
      this.isCreating = false;
    }
    , sendForm() {
      if (this.message.length > 0) {
        var message = this.message;
        var date = new Date(Date.now());
        var hours = date.getHours() < 10 ? "0"+date.getHours() : date.getHours();
        var minutes = date.getMinutes() < 10 ? "0"+date.getMinutes() : date.getMinutes();
        var seconds = date.getSeconds() < 10 ? "0"+date.getSeconds() : date.getSeconds();
        var month = (date.getMonth()+1) < 10 ? "0"+(date.getMonth()+1) : (date.getMonth()+1);
        var day = date.getDate < 10 ? "0"+date.getDate() : date.getDate();
        var LastConfirmDate = date.getFullYear() + "-" + month + "-" + day + "T" + hours + ":" + minutes + ":" + seconds + "+03:00";
        var CreatedDate = LastConfirmDate;
        var post = 
        {
          Id: 1
          , Date: CreatedDate
          , Message: message
          , LastConfirmDate
        };
        this.$store.dispatch('createPost', post)
        .then(post => console.log(post))
        .catch(e => console.loge(e));
        this.message = '';
        this.closeForm();
      }
    }
  }
};
</script>