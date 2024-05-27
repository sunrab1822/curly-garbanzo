const mongoose = require("mongoose");

const SeasonSchema = new mongoose.Schema({
  _id: {
    type: Number,
    required: true
  },
  season: {
    type: String
  },
  years: {
    type: String
  }
});

module.exports = mongoose.model("SeasonModel", SeasonSchema, "seasons"); // ezzel a névvel lesz létrehozva a kollekció.
