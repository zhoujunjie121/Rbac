<template>
  <div>
    <el-container>
      <el-header>权限管理系统</el-header>
      <el-container>
        <el-aside width="200px">
           <el-menu
      default-active="/menulist"
      class="el-menu-vertical-demo"
      @open="handleOpen"
      @close="handleClose"
      background-color="#545c64"
      text-color="#fff"
      active-text-color="#ffd04b"
      :router="true" :unique-opened="false">
      <el-submenu :index="item.menuLink" v-for="item in MenuList" :key="item.menuId">
        <template slot="title">
          <i class="el-icon-location"></i>
          <span>{{item.menuName}}</span>
        </template>

        <el-menu-item-group >
        <!--   <el-menu-item v-for="iteme in tableData.filter(t=>t.pId==item.menuId)" :key="iteme.menuId">
      </el-menu-item> -->
      <template v-for="iteme in tableData.filter(t=>t.pId==item.menuId)">

          <el-menu-item :index="menuitem.menuLink" v-for="menuitem in tableData.filter(t=>t.pId==iteme.menuId && t.isShow)" :key="menuitem.menuId">
            {{menuitem.menuName}}
            </el-menu-item>
      </template>
          
        </el-menu-item-group>

      </el-submenu>
    </el-menu>
        </el-aside>
        <el-main>
           <router-view/>
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        tableData: [{
        }]
      }
    },
    methods: {
      handleOpen(key, keyPath) {
        console.log(key, keyPath);
      },
      handleClose(key, keyPath) {
        console.log(key, keyPath);
      },
      menu(){
        this.$http.get("/api/menu/QueryMenuList").then(res=>{
            this.tableData=res.data;
            console.log(this.tableData);
        })
      }
    },
    created(){
      this.menu();
    },
    computed:{
      MenuList(){
        return this.tableData.filter(t=>t.pId==0)
      },
    }
    
  }
</script>

<style>
.el-menu-vertical-demo{
  text-align: left;
  border-right: 0;
}
  .el-header, .el-footer {
    background-color: #B3C0D1;
    color: #333;
    text-align: center;
    line-height: 60px;
    font-weight: bold;
  }
  
  .el-aside {
    background-color: #545c64;
    color: #333;
    text-align: center;
    line-height: 200px;
  }
  
  .el-main {
    background-color: #E9EEF3;
    color: #333;
    text-align: center;
    line-height: 60px;
    height:calc(100vh - 60px);
  }
  
  body > .el-container {
    margin-bottom: 40px;
  }
  
  .el-container:nth-child(5) .el-aside,
  .el-container:nth-child(6) .el-aside {
    line-height: 260px;
  }
  
  .el-container:nth-child(7) .el-aside {
    line-height: 320px;
  }
</style>
