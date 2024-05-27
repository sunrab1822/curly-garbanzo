<script setup>
import DataService from "../services/dataservice";
import { ref } from "vue";

const episodes = ref([]);
const maxPage = ref(1);
const maxCount = ref(0);
const page = ref(1)
const Search = ref("where");
const isfirst = ref(true)
const isLast = ref(true)

const getEps = () => {
  DataService.getEpisodesByID(Search.value, page.value)
  .then((resp) => {
    episodes.value = resp.data;
    maxCount.value = resp.headers["x-total-count"];
    maxPage.value = Math.ceil(maxCount.value /15)
  })
  .catch((err) => {
    console.log(err);
  });
}

getEps()

const lep = (actPage) => {

  isLast.value = false
  isfirst.value = false
  page.value = actPage;

  DataService.getEpisodesByID(Search.value, page.value)
  .then((resp) => {
    episodes.value = resp.data;
    maxCount.value = resp.headers["x-total-count"];
    maxPage.value = Math.ceil(maxCount.value /15)
  })
  .catch((err) => {
    console.log(err);
  });
}

</script>

<template>
          <div id="filter" class="input-group input-group-lg my-3" >
            <span class="input-group-text">Filter</span>
            <input type="text" placeholder="where" class="form-control" @keyup="getEps" v-model="Search">
        </div>

        <nav>
            <ul class="pagination justify-content-center">
                <li class="page-item" v-if="page != 1"><button class="page-link" @click="lep(1)">First</button></li>
                <li class="page-item" v-if="page != 1"><button class="page-link" @click="lep(page-1)">Prev</button></li>
                <li class="page-item disabled" v-if="page == 1"><button class="page-link" @click="lep(1)">First</button></li>
                <li class="page-item disabled" v-if="page == 1"><button class="page-link" @click="lep(page-1)">Prev</button></li>
                <li class="page-item" v-if="page != maxPage" ><button class="page-link" @click="lep(page + 1)">Next</button></li>
                <li class="page-item" v-if="page != maxPage" ><button class="page-link" @click="lep(maxPage)">Last</button></li>
                <li class="page-item disabled" v-if="page == maxPage" ><button class="page-link" @click="lep(page + 1)">Next</button></li>
                <li class="page-item disabled"  v-if="page == maxPage" ><button class="page-link" @click="lep(maxPage)">Last</button></li>
            </ul>
        </nav>

    <div id="cards" class="container text-center">
        <div class="row">
            <div class="col-md-4 my-4" v-for="episode in episodes">
                <div class="card text-center">
                    <div class="card-header bg-info fw-bold">
                        {{ episode.name }}
                    </div>
                    <img :src="episode.image.medium" class="card-img-top" alt="Friends">
                    <div class="card-body bg-warning">
                        <p class="card-text fw-bold">{{ episode.summary }}</p>
                    </div>
                    <div class="card-footer bg-info fw-bold">
                        Season: {{ episode.season.season }}, years: {{ episode.season.years }}
                    </div>
                </div>
            </div>
        </div>
    </div>

   <footer class="bg-primary">
        <p class="text-center text-white fs-3">Number of total records: {{ maxCount }}</p>
    </footer>

</template>
