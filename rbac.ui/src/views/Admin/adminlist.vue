<template>
  <div>
    <el-table :data="tableData" style="width: 100%">
      <el-table-column prop="userName" label="用户名" width="180">
      </el-table-column>

      <el-table-column prop="email" label="邮箱" width="180"> </el-table-column>

      <el-table-column prop="createTime" label="创建时间" width="180">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{ scope.row.createTime }}</span>
        </template>
      </el-table-column>

      <el-table-column label="是否锁定" width="180">
        <template slot-scope="scope">
          <span v-if="scope.row.isLock == true">是</span>
          <span v-else>否</span>
        </template>
      </el-table-column>

      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.row.adminId)"
            >编辑</el-button
          >
          <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.row.adminId)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <el-pagination
      background
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
      :current-page="page.pageIndex"
      :page-sizes="[2, 5, 7, 15]"
      :page-size="page.pageSize"
      layout="total, sizes, prev, pager, next, jumper"
      :total="totalCount"
    >
    </el-pagination>

    <el-dialog title="管理员修改" :visible.sync="dialogTableVisible">
    <admin-upd @Adminupd="Adminupd" :AdminId=adminId></admin-upd>
    </el-dialog>
  </div>
</template>

  <script>
import AdminUpd from "@/views/Admin/adminUpd.vue";
export default {
  components: {
    AdminUpd,
  },
  data() {
    return {
      adminId:0,
      dialogTableVisible: false,
      tableData: [{}],
      page: {
        pageIndex: 1,
        pageSize: 2,
      },
      totalCount: 0,
    };
  },
  methods: {
    Show() {
      this.$http.get("/api/admin/GetQuery", { params: this.page }).then((res) => {
          this.tableData = res.data.data;
          this.totalCount = res.data.totalCount;
          console.log(res);
        });
    },
    handleSizeChange(val) {
      this.page.pageSize = val;
      this.Show();
    },
    handleCurrentChange(val) {
      this.page.pageIndex = val;
      this.Show();
    },
    handleEdit(id) {
      this.adminId=id;
      console.log(id);
      this.dialogTableVisible = true;
    },
    Adminupd(val){
      this.dialogTableVisible=!val;
      this.Show();
    },
    handleDelete(id){
      this.$confirm('此操作将永久删除该文件, 是否继续?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(() => {
           this.$http.get("/api/Admin/Delete?id="+id).then(res=>{
             if(res.data==500){
                this.$message.error("该菜单有子节点，不能删除");
            } 
            else if(res.data>0){
               this.$message({
                type: 'success',
                message: '删除成功!'
                });
            }
            else{
              this.$message.error("删除失败");
            }
          })
        }).catch(() => {
          this.$message({
            type: 'info',
            message: '已取消删除'
          });          
        });
    }
  },
  created() {
    this.Show();
  },
};
</script>