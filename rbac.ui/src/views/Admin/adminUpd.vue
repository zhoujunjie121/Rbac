<template>
    <div>


<el-form ref="form" :model="form" label-width="80px">

  <el-form-item label="用户名">
    <el-input v-model="form.userName" readonly="true"></el-input>
  </el-form-item>


  <el-form-item label="密码" prop="password">
    <el-input type="password" v-model="form.password" autocomplete="off"></el-input>
  </el-form-item>

   <el-form-item label="邮箱">
    <el-input v-model="form.email"></el-input>
  </el-form-item>

  <el-form-item>
    <el-button type="primary" @click="onSubmit">保存</el-button>
    <el-button>取消</el-button>
  </el-form-item>
</el-form>
    </div>
</template>


<script>
  export default {
    data() {
      return {
        form: {
          userName:'',
          password:'',
          email:'',
        }
      }
    },
    methods: {
      onSubmit() {
        console.log('submit!');
      }
    }
  }
</script>