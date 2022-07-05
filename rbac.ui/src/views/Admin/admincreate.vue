<template>
    <div>

<el-card class="box-card loginform">
  <div slot="header" class="clearfix" >
    <span>卡片名称</span>
    <el-button style="float: right; padding: 3px 0" type="text">操作按钮</el-button>
  </div>
   <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
  <el-form-item label="用户名" prop="userName">
    <el-input v-model="ruleForm.userName"></el-input>
  </el-form-item>

   <el-form-item label="密码" prop="password">
    <el-input type="password" v-model="ruleForm.password" autocomplete="off"></el-input>
  </el-form-item>

  
  <el-form-item label="邮箱">
    <el-input v-model="ruleForm.email"></el-input>
  </el-form-item>

  <el-form-item label="角色">
   <el-select v-model="ruleForm.roleId" multiple placeholder="请选择">
    <el-option
      v-for="item in options"
      :key="item.roleId"
      :label="item.roleName"
      :value="item.roleId">
    </el-option>
  </el-select>
  </el-form-item>

 <el-form-item>
    <el-button type="primary" @click="submitForm()">注册</el-button>
    <el-button @click="resetForm('ruleForm')">重置</el-button>
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
          userName:'',
          password:'',
          email:'',
          roleId:0,
        },
        rules: {
          userName: [
            { required: true, message: '请输入用户名', trigger: 'blur' },
            { min: 3, max: 10, message: '长度在 3 到 10 个字符', trigger: 'blur' }
          ],
          password: [
            { required: true, message: '请输入密码', trigger: 'change' }
          ],

          email: [
            { required: true, message: '请输入邮箱', trigger: 'change' }
          ],
        },
        options:[],
      };
    },
    methods: {
        submitForm(){
          this.$http.post("/api/Admin/Create",this.ruleForm).then(res=>{
              if(res.data.code>0){
                  this.$message.error(res.data.msg);
              }
              else{
                  this.$message.success(res.data.msg);
                  this.$router.push("/");
              }
          })
        },
        show(){
          this.$http.get("/api/Role/Query").then(res=>{
            this.options=res.data;
            console.log(res);
          })
        }
    },
    created(){
      this.show();
    }
  }
</script>

<style>
  .loginform{
     margin: 0 auto;
    margin-top: 10em;
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
    width: 600px;
  }
</style>