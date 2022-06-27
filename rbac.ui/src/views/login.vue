<template>
    <div class="login">
        <el-card class="box-card loginform" >
            <div slot="header" class="clearfix">
                <span>登录</span>
                <el-button style="float: right; padding: 3px 0" type="text" @click="Admin">注册</el-button>
             </div>
            <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
               <el-form-item label="用户名" prop="userName">
                    <el-input v-model="ruleForm.userName"></el-input>
                </el-form-item>
                <el-form-item label="密码" prop="password">
                    <el-input type="password" v-model="ruleForm.password" autocomplete="off"></el-input>
                </el-form-item>
                
                <el-form-item>
                    <el-button type="primary" @click="onSubmit">登录</el-button>
                    <el-button>取消</el-button>
                </el-form-item>
            </el-form>
        </el-card>
    </div>
</template>
<script>
  export default {
    data() {
      return {
        ruleForm: {
          userName: '',
          password: '',
        },
        rules: {
          userName: [
            { required: true, message: '请输入活动名称', trigger: 'blur' },
            { min: 3, max: 10, message: '长度在 3 到 10 个字符', trigger: 'blur' }
          ],
          password:[
             { required: true, message: '请输入密码', trigger: 'blur' },
            { min: 3, max: 10, message: '长度在 3 到 10 个字符', trigger: 'blur' }
          ]
        }
      };
    },
    methods: {
        onSubmit(){
            this.$http.get("/api/Admin/GetLogin",{params:this.ruleForm}).then(res=>{
                if(res.data.code>0){
                    this.$message.error(res.data.msg)
                }
                else{
                    localStorage.setItem("token",res.data.token)
                    this.$router.push("/about");
                }
            })
        },
      Admin(){
        this.$router.push("/admincreate");
      }
    }
  }
</script>


<style>
  .login{
    background: rgba(33, 157, 43, 0.722);
    width: 100%;
    height: 100%;
    padding-top:7em ;
  }
  .loginform{
    margin: 0 auto;
    margin-top: 7em;
    overflow: hidden;
    }
  .text {
    font-size: 14px;
  }

  .item {
    margin-bottom: 18px;
  }

  .clearfix:before,
  .clearfix:after {
    display: table;
    content: "";
  }
  .clearfix:after {
    clear: both
  }

  .box-card {
    width: 480px;
  }
</style>