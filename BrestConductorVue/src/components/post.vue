<template>
    <div class="form">
        <div class = "top">
            Last update: {{lastConfirm}}
        </div>
        <div class="formMessage">
            {{post.Message}}
        </div>
        <div class="divOfButton">
            <img src="../assets/refresh.png" height="45px" width="50px" v-show = "isConfirm == false" v-on:click = "clickConfrim" style="cursor: pointer; margin-bottom: 0px;margin-top: 10px;">
        </div>
        <div class="divOfButton">
            <img src="../assets/confirm.png" height="50px" width="50px"  v-show = "isConfirm" style="margin-bottom: 0px;margin-top: 5px;">
        </div>
        <br/>
    </div>
</template>

<script>
    import api from '../api/api';
    export default
    {
        props: ['post']
        , data()
        {
            return { 
                isConfirm: false
            };
        }
        , methods: 
        {
            dateTime(_date){
                var date = new Date(_date);
                var hours = date.getHours() < 10 ? "0"+date.getHours() : date.getHours();
                var minutes = date.getMinutes() < 10 ? "0"+date.getMinutes() : date.getMinutes();
                return hours + ":" + minutes;
            }

            , clickConfrim()
            {
                this.isConfirm = true;
                var date = new Date(Date.now());
                var hours = date.getHours() < 10 ? "0"+date.getHours() : date.getHours();
                var minutes = date.getMinutes() < 10 ? "0"+date.getMinutes() : date.getMinutes();
                var seconds = date.getSeconds() < 10 ? "0"+date.getSeconds() : date.getSeconds();
                var month = (date.getMonth()+1) < 10 ? "0"+(date.getMonth()+1) : (date.getMonth()+1);
                var day = date.getDate() < 10 ? "0"+date.getDate() : date.getDate();
                this.post.LastConfirmDate = date.getFullYear() + "-" + month + "-" + day + "T" + hours + ":" + minutes + ":" + seconds + "+03:00";
                this.$store.dispatch('editPost', this.post)
                .then(post => console.log(post))
                .catch(e => console.loge(e));
            }
        }
        , computed:
        {
            lastConfirm()
            {
                return this.dateTime(this.post.LastConfirmDate);
            }
        }
    }
</script>