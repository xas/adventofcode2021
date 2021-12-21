import { expect } from "chai";
import { ethers } from "hardhat";
import * as fs from "fs";
import * as readline from "node:readline";

describe("Day 01", function () {
  it("Fill for Part 01", async function () {
    const Day01 = await ethers.getContractFactory("Day01");
    const day01 = await Day01.deploy();
    await day01.deployed();

    await day01.initPart01(137);

    const fileStream = fs.createReadStream('inc/day01.txt');

    const rl = readline.createInterface({
      input: fileStream,
      crlfDelay: Infinity
    });
  
    for await (const line of rl) {
      // Each line in input.txt will be successively available here as `line`.
      day01.fillPart01(parseInt(line));
    }

    expect(await day01.part01()).to.equal(1711);
  });

  it("Fill for Part 02", async function () {
    const Day01 = await ethers.getContractFactory("Day01");
    const day01 = await Day01.deploy();
    await day01.deployed();

    await day01.initPart02();

    const fileStream = fs.createReadStream('inc/day01.txt');

    const rl = readline.createInterface({
      input: fileStream,
      crlfDelay: Infinity
    });
  
    for await (const line of rl) {
      // Each line in input.txt will be successively available here as `line`.
      day01.fillPart02(parseInt(line));
    }

    expect(await day01.part02()).to.equal(1743);
  });
});
