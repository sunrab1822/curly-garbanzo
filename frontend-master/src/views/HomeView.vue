<script setup>
import DataService from "../services/dataservice";
import { ref } from "vue";

const brands = ref([]);
const BrandId = ref(1);
const watches = ref([])

DataService.getAllCategory()
  .then((resp) => {
    brands.value = resp;
    console.log(brands.value);
  })
  .catch((err) => {
    console.log(err);
  });



const valaszto = () => {
  DataService.getByID(BrandId.value)
    .then((resp) => {
      watches.value = resp;
      console.log(watches.value);
    })
    .catch((err) => {
      console.log(err);
    });
};

valaszto()

</script>

<template>
  <div class="form">
    <div class="data">
      <label for="location">Hegység:</label>
      <select name="locationId" id="location" v-model="BrandId" @change="valaszto">
        <option value="1" selected>Kérem válasszon</option>
        <option v-for="brand in brands" :value="brand.id">{{ brand.Name }}</option>
      </select>
    </div>
  </div>

  <div id="viewpoints" >
    <div class="viewpoint" v-for="watche in watches">
      <h2>{{ watche.Model }}</h2>
      <div>
        <ul>
          <li>
            <label>Ár:</label>
            <span>{{ watche.Price_USD }}</span>
          </li>
          <li>
            <label>Ár:</label>
            <span>{{ watche.Price_USD }}</span>
          </li>
          <li>
            <label>Ár:</label>
            <span>{{ watche.Price_USD }}</span>
          </li>
          <li>
            <label>Ár:</label>
            <span>{{ watche.Price_USD }}</span>
          </li>
        </ul>
      </div>
      <p class="description">
        {{ watche.ProductDescription }}
      </p>
    </div>

  </div>

</template>
