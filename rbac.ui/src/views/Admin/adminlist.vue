<template>
  <div>
    <el-table :data="tableData" style="width: 100%">
      <el-table-column prop="userName" label="用户名" width="180">
      </el-table-column>

      <el-table-column prop="email" label="邮箱" width="180"> </el-table-column>

      <el-table-column prop="createTime" label="创建时间" width="180">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{ scope.row.createTime}}</span>
        </template>
      </el-table-column>

      <el-table-column label="是否锁定" width="180">
        <template slot-scope="scope">
          <span v-if="scope.row.isLock == true">是</span>
          <span v-else>否</span>
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
  </div>
</template>

  <script>
export default {
  data() {
    return {
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
      this.$http
        .get("/api/admin/GetQuery", { params: this.page })
        .then((res) => {
          this.tableData = res.data.data;
          this.totalCount=res.data.totalCount;
          console.log(res);
        });
      },
      handleSizeChange(val) {
        this.page.pageSize=val;
        this.Show();
      },
      handleCurrentChange(val) {
        this.page.pageIndex=val;
        this.Show();
      },
      },
      created() {
        this.Show();
      },
};
</script>