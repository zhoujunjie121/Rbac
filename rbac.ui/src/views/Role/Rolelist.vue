<template>
<div>


  <el-table
    :data="tableData"
    style="width: 100%">

    <el-table-column
      prop="roleId"
      label="编号"
      width="180">
    </el-table-column>

    <el-table-column
      prop="roleName"
      label="角色名称"
      width="180">
    </el-table-column>


    <el-table-column
      label="创建日期"
      width="180">
      <template slot-scope="scope">
        <i class="el-icon-time"></i>
        <span style="margin-left: 10px">{{ scope.row.CreateTime }}</span>
      </template>
    </el-table-column>
    
    <el-table-column label="操作">
      <template slot-scope="scope">
        <el-button
          size="mini"
          @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button
          size="mini"
          @click="authority(scope.row.roleId)">权限分配</el-button>
        <el-button
          size="mini"
          type="danger"
          @click="handleDelete(scope.$index, scope.row)">删除</el-button>
      </template>
    </el-table-column>
  </el-table>
  
<el-dialog title="权限分配" :visible.sync="dialogTableVisible">
    <menu-tree ref="dialogmenu"></menu-tree>
     <span slot="footer" class="dialog-footer">
    <el-button @click="dialogTableVisible = false">取 消</el-button>
    <el-button type="primary" @click="Save()">确 定</el-button>
  </span>
</el-dialog>
  </div>
</template>

<script>
import MenuTree from '@/views/Role/Menutree.vue'
  export default {
    components: {
    MenuTree
  },
    data() {
      return {
        tableData: [],
        roleId:0,
        dialogTableVisible:false,
      }
    },
    methods: {
        handleEdit(index, row) {
            console.log(index, row);
        },
        handleDelete(index, row) {
            console.log(index, row);
        },
        Show(){
            this.$http.get("/api/role/Query").then(res=>{
                this.tableData=res.data;
            })
        },
        authority(id){
            this.roleId=id;
            console.log(id);
            this.dialogTableVisible=true;
        },
        Save(){
            console.log(this.$refs.dialogmenu.$refs.Menutree.getCheckedNodes(true,true).map(t=>t.value));
            var form={
                roleId:this.roleId,
                menuId:this.$refs.dialogmenu.$refs.Menutree.getCheckedNodes(true,true).map(t=>t.value),
            };
            this.$http.post("/api/Role/CreateRoleMenu",form).then(res=>{
                if(res.data>0){
                    this.$message.success("分配成功");
                }
                else{
                    this.$message.success("分配失败")
                }
            })
            
            this.dialogTableVisible=false;
        }
    },
    created(){
        this.Show();
    }
  }
</script>