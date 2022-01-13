import { expect } from "chai";
import { ethers } from "hardhat";
import * as fs from "fs";
import * as readline from "node:readline";

describe("Day 03", function () {
  it("Fill for Part 03", async function () {
    const Day03 = await ethers.getContractFactory("Day03");
    const day03 = await Day03.deploy();
    await day03.deployed();

    const fileStream = fs.createReadStream('inc/day03.txt');

    const rl = readline.createInterface({
      input: fileStream,
      crlfDelay: Infinity
    });
  
    for await (const line of rl) {
      // Each line in input.txt will be successively available here as `line`.
      day03.fillPart01(parseInt(line, 2));
    }

    expect(await day03.part01()).to.equal(2595824);
    await day03.part02Oxygen();
    await day03.part02Dioxygen();
    expect(await day03.part02()).to.equal(2135254);
  });
});
