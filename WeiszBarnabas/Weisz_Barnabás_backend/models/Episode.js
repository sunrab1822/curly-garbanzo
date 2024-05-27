const mongoose = require("mongoose");

const EpisodeSchema = new mongoose.Schema({
  _id: {
    type: Number,
    required: true
  },
  url: {
    type: String
  },
  name: {
    type: String
  },
  seasonId: {
    type: Number,
    unique: true,
    ref: "SeasonModel"
  },
  number: {
    type: Number
  },
  airstamp: {
    type: Date
  },
  runtime: {
    type: Number
  },
  image_medium: {
    type: String,
    default: "https://bgs.jedlik.eu/no_image.png"
  },
  image_original: {
    type: String,
    default: "https://bgs.jedlik.eu/no_image.png"
  },
  summary: {
    type: String
  }
});

module.exports = mongoose.model(
  "EpisodeModel",
  EpisodeSchema,
  "episodes"
);
