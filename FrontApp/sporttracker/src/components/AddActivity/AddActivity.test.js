import React from "react";
import { shallow } from "enzyme";
import AddActivity from "./AddActivity";

describe("AddActivity", () => {
  test("matches snapshot", () => {
    const wrapper = shallow(<AddActivity />);
    expect(wrapper).toMatchSnapshot();
  });
});
