const express = require("express");
const EpisodeModel = require("../models/Episode");
const SeasonModel = require("../models/Season");

const router = express.Router();

router.post("/add-season", async (req, res) => {
  const data = new SeasonModel(req.body);

  try {
    const dataToSave = await data.save();
    res.status(201).json({ _id: dataToSave._id });
  } catch (error) {
    res.status(400).json({ message: "Hiányos adatok!" });
  }
});


router.get("/search-by-season/:season", async (req, res) => {
  try {
    const season = await SeasonModel.findOne({season: req.params.season})
    const data = await EpisodeModel.find({ seasonId: season._id})
    res.status(200).json(data);

  } catch (error) {
    res.status(404).json({ message: "Hibás évad!" });
  }
});

//Delete by ID Method
router.delete("/delete-season/:id", async (req, res) => {
  try {
    const id = req.params.id;
    const episodes = await EpisodeModel.find({seasonId: id})
    if (episodes.length > 0){
      res.status(403).send("Az évad nem törölhető!");
      return
    }
    const data = await SeasonModel.findByIdAndDelete(id);
    if (data == null){
      res.status(404).send("Az évad nem létezik!");
      return
    }
    res.status(204).send();
  } catch (error) {
    res.status(400).json({ message: error.message });
  }
});

module.exports = router;
