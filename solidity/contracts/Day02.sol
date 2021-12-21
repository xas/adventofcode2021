//SPDX-License-Identifier: Unlicense
pragma solidity ^0.8.0;

import "hardhat/console.sol";

contract Day02 {
    uint32 private _depth;
    uint32 private _aim;
    uint32 private _horizon;
    uint32 private _lastTotal;
    bytes32 private _forward;
    bytes32 private _up;
    bytes32 private _down;

    constructor() {
        _forward = keccak256(bytes("forward"));
        _up = keccak256(bytes("up"));
        _down = keccak256(bytes("down"));
    }

    function fill(uint32 _value, string memory _direction) public {
        bytes32 _hashedDirection = keccak256(bytes(_direction));
        if (_hashedDirection == _forward) {
            _horizon += _value;
            _depth += _value * _aim;
        }
        else if (_hashedDirection == _up) {
            _aim -= _value;
        }
        else if (_hashedDirection == _down) {
            _aim += _value;
        }
    }

    function part01() public view returns (uint32, uint32) {
        console.log("Day 02.01 : depth = %s | horizon = %s", _depth, _horizon);
        return (_depth, _horizon);
    }

    function part02() public view returns (uint32) {
        console.log("Day 02.02 : ", _depth * _horizon);
        return _depth * _horizon;
    }
}
