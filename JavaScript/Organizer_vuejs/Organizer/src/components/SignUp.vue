<template>
    <div class="card card-container">
            <form class="form-signin" @submit.prevent="registerUsers">
                <input type="email" id="inputEmail" class="form-control" placeholder="Email address" v-model="user.email" required>
                <input type="password" id="inputPassword" class="form-control" placeholder="Password" v-model="user.password" required>
                <input type="password" id="confirmpassword" class="form-control" placeholder="Password" v-model="user.confirmpassword" required>
                <button class="btn btn-lg btn-primary btn-block btn-signin" type="submit">Sign Up</button>
                 <div  v-if="check" class="alert alert-danger" role="alert"> {{erro}} </div>
            </form>
    </div>
</template>

<script>
export default {
    data: ()=>{
        return  {
            user: {
                email: '',
                password: '',
                confirmpassword: ''
            },
            check: false,
            erro: '',
            succes: false
        }
    },
    methods:{
        registerUsers(){
            if(this.user.password !== this.user.confirmpassword){
                this.erro = "Пароли не совпадают";
            } 
            else {
                firebase.auth().createUserWithEmailAndPassword(this.user.email, this.user.password)
                .then( ()=> {
                    this.succes = true;
                    this.user = {email: '', password: '', confirmpassword: ''};
                    this.$emit("registerSuccess", false);
                })
                .catch(erro => {
                    this.check = true;
                    this.erro = erro.message;
                });
            }
        }
    }
}
</script>

<style>
.card-container.card {
    max-width: 350px;
    padding: 40px 40px;
}

.btn {
    font-weight: 700;
    height: 36px;
    -moz-user-select: none;
    -webkit-user-select: none;
    user-select: none;
    cursor: default;
}

.card {
    background-color: #F7F7F7;
    -moz-border-radius: 2px;
    -webkit-border-radius: 2px;
    border-radius: 2px;
    -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
    -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
    box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
}

.reauth-email {
    display: block;
    color: #404040;
    line-height: 2;
    margin-bottom: 10px;
    font-size: 14px;
    text-align: center;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
}

.form-signin #inputEmail,
.form-signin #inputPassword {
    direction: ltr;
    height: 44px;
    font-size: 16px;
}
.form-signin button {
    width: 100%;
    display: block;
    margin-bottom: 10px;
    z-index: 1;
    position: relative;
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
}

.form-signin .form-control:focus {
    border-color: rgb(104, 145, 162);
    outline: 0;
    -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
    box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
}

.btn.btn-signin {
    background-color: rgb(104, 145, 162);
    padding: 0px;
    font-weight: 700;
    font-size: 14px;
    height: 36px;
    -moz-border-radius: 3px;
    -webkit-border-radius: 3px;
    border-radius: 3px;
    border: none;
    -o-transition: all 0.218s;
    -moz-transition: all 0.218s;
    -webkit-transition: all 0.218s;
    transition: all 0.218s;
}

.btn.btn-signin:hover,
.btn.btn-signin:active,
.btn.btn-signin:focus {
    background-color: rgb(12, 97, 33);
}

.forgot-password {
    color: rgb(104, 145, 162);
}

.forgot-password:hover,
.forgot-password:active,
.forgot-password:focus{
    color: rgb(12, 97, 33);
}

</style>
