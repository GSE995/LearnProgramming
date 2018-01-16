<template>

            <div class="row">
                <div class="col-md-12">Войти с помощью
                    <div class="social-buttons" style="width: 80%">
                        <a class="btn btn-fb" style="width: 20%"><i class="fa fa-facebook"></i></a>
                       <a class="btn btn-tw" style="width: 20%"><i class="fa fa-twitter"></i></a>
                        <a class="btn btn-vk" style="width: 20%"><i class="fa fa-vk"></i></a>
                    </div>
                    <form class="form" role="form" method="post" action="login" accept-charset="UTF-8" id="login-nav">
                        <div class="form-group" v-if="signup">
                            <label class="sr-only" for="exampleInputEmail2">Name</label>
                            <input type="email" class="form-control" id="exampleInputEmail2" placeholder="Name" required>
                        </div>
                        <div class="form-group" v-if="signup">
                            <label class="sr-only" for="exampleInputEmail2">Suraname</label>
                            <input type="email" class="form-control" id="exampleInputEmail2" placeholder="Suraname" required>
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="exampleInputEmail2">Email address</label>
                            <input type="email" class="form-control" id="exampleInputEmail2" placeholder="Email address" required>
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="exampleInputPassword2">Password</label>
                            <input type="password" class="form-control" id="exampleInputPassword2" placeholder="Password" required>
                            <div class="help-block text-right" v-if="!signup"><a>Забыли пароль ?</a></div>
                        </div>

                        <div class="form-group" v-if="signup">
                            <label class="sr-only" for="exampleInputPassword2">Password</label>
                            <input type="password" class="form-control" id="exampleInputPassword2" placeholder="Confirm password" required>
                        </div>
                        <div class="form-group">
                            <button type="submit" class="btn btn-primary btn-block">Зарегистрироваться</button>
                        </div>
                    </form>
                </div>
            </div>
</template>

<script>
export default {
  data(){
    return{
      signup: true,
      name: '',
      surename: '',
      email: '',
      password: '',
      confirmpassword: '',
      uid: ''
    }
  }

}
</script>

<style>

.dropdown-menu.pop{
    background-color:rgba(255,255,255,.8);
}

.btn-vk{
  color:#fff;
  background-color:#587ea3;
  border-color:rgba(0,0,0,0.2)
  }

.btn-fb{
    color: #fff;
    background-color:#3b5998;
}
.btn-fb:hover{
    color: #fff;
    background-color:#496ebc
}
.btn-tw{
    color: #fff;
    background-color:#55acee;
}
.btn-tw:hover{
    color: #fff;
    background-color:#59b5fa;
}

#login-dp .social-buttons{
    margin:12px 0
}
#login-dp .social-buttons a{
    width: 40%;
}

#login-dp .help-block{
    font-size:12px
}

#login-dp .bottom{
    background-color:rgba(255,255,255,.8);
    border-top:1px solid #ddd;
    clear:both;
    padding:14px;
}

#login-dp .form-group {
    margin-bottom: 10px;
}

#login-dp{
    min-width: 250px;
    padding: 14px 14px 0;
    overflow:hidden;

}

</style>
