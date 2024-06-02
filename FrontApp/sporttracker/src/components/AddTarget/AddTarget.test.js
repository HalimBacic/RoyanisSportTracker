import React from "react";
import { shallow } from "enzyme";
import AddTarget from "./AddTarget";

describe("AddTarget", () => {
  test("matches snapshot", () => {
    const wrapper = shallow(<AddTarget />);
    expect(wrapper).toMatchSnapshot();
  });
});
