<template>
  <div>
    <el-tree
      ref="Menutree"
      :data="data"
      show-checkbox
      node-key="value"
      :props="defaultProps"
    >
    </el-tree>
    <el-button @click="getdate">aaa</el-button>
  </div>
</template>


<script>
export default {
  data() {
    return {
      data: [],
      defaultProps: {
        id: 'value',
        label: 'label',
        children: 'children',
      }
    };
  },
  methods: {
    Show() {
      this.$http.get("/api/menu/QueryCreateMeun").then((res) => {
         var reg = new RegExp('\\,"children":\\[]', 'g');
        this.data=JSON.parse(JSON.stringify(res.data).replace(reg, ''));
        console.log(res);
      });
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