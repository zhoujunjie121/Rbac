<template>
  <div>
    <!-- <el-tree
      ref="Menutree"
      :data="data"
      show-checkbox
      node-key="value"
      :props="defaultProps"
    >
    </el-tree>
    <el-button @click="getdate">aaa</el-button> -->

    <el-tree
      ref="Menutree"
      :data="data"
      show-checkbox
      node-key="value"
      :default-checked-keys="values"
      :default-expand-all="true"
      :props="defaultProps">
    </el-tree>

  </div>
</template>


<script>
export default {
    //props:['RoleIds'],
  data() {
    return {
      data: [],
      //RoleIds:this.RoleIds,
      defaultProps: {
        id: 'value',
        label: 'label',
        children: 'children',
      },
      values:[],
    };
  },
  props:{
    RoleIds:{
      type:Number
    }
  },
  methods: {
    Show() {
      this.$http.get("/api/menu/QueryCreateMeun").then((res) => {
         var reg = new RegExp('\\,"children":\\[]', 'g');
        this.data=JSON.parse(JSON.stringify(res.data).replace(reg, ''));
        //console.log(res);
      });
      console.log(this.RoleIds);
   
      this.$http.get(`/api/Role/GetRoleMenuById?RoleId=${this.RoleIds}`).then(res=>{
          this.values=res.data.map(t=>t.menuId);
      })
    },
    getdate(){
      console.log(this.$refs.Menutree.getCheckedNodes(true,true).map(t=>t.value));
    }
  },
  created() {
    this.Show();
  },
};
</script>