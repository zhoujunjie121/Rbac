<template>
    <div>
         <el-table
      :data="tableData"
      style="width: 100%">

      <el-table-column
        prop="userName"
        label="用户名"
        width="180">
      </el-table-column>

      <el-table-column
        prop="email"
        label="邮箱"
        width="180">
      </el-table-column>


      <el-table-column
        prop="createTime"
        label="创建时间"
        width="180">
         <template slot-scope="scope">
        <i class="el-icon-time"></i>
        <span style="margin-left: 10px">{{ scope.row.createTime }}</span>
      </template>
      </el-table-column>

      <el-table-column
        label="是否锁定"
        width="180">
         <template slot-scope="scope">
          <span v-if="scope.row.isLock==true">是</span>
          <span v-else>否</span>
      </template>
      </el-table-column>

    </el-table>
    </div>
</template>

  <script>
    export default {
      data() {
        return {
          tableData: [{}],
          page:{
            pageIndex:1,
            pageSize:2,
          }
        }
      },
      methods:{
        Show(){
          this.$http.get("/api/admin/GetQuery",{params:this.page}).then(res=>{
            this.tableData=res.data.data;
            console.log(res);
          })
        }
      },
      created(){
        this.Show();
      }
    }
  </script>