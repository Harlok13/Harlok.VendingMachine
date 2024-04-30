import {v4} from "uuid";

class Money {
    constructor(denomination) {
        this._denomination = denomination;
        this._id = v4();
    }

    getDenomination = () => this._denomination;
    getId = () => this._id;
}

export default Money;