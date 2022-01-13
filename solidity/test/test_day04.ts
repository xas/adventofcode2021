import { expect } from "chai";
import { ethers } from "hardhat";
import * as fs from "fs";
import * as readline from "node:readline";

describe("Day 04", function () {
  let firstline: string = "";
  it("Fill for Part 04.01", async function () {
    this.timeout(0);
    const Day04 = await ethers.getContractFactory("Day04");
    const day04 = await Day04.deploy();
    await day04.deployed();

    const fileStream = fs.createReadStream('inc/day04.txt');

    const rl = readline.createInterface({
      input: fileStream,
      crlfDelay: Infinity
    });
  
    let counter = 0;
    let numbers: number[] = [];
    console.log("Filling...");
    for await (const line of rl) {
      if (counter == 0) {
        firstline = line.trim();
      }
      else if (line.trim().length > 0) {
        numbers = numbers.concat(line.trim().split(/\ +/).map(Number));
      }
      else if (counter > 2 && line.trim().length == 0) {
        await day04.fill(numbers);
        numbers = [];
      }
      counter++;
    }
    // Don't forget the last one
    await day04.fill(numbers);

    console.log("Calling...");
    const draws = firstline.split(',').map(Number);
    for await (const element of draws) {
      await day04.draw(element);
    };

    expect(await day04.firstLineTotal()).to.equal(2496);
    expect(await day04.lastWinnerTotal()).to.equal(25925);
  });
});
