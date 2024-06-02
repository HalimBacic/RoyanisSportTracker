import React from "react";
import { shallow } from "enzyme";
import SportTracker from "./SportTracker";

describe("SportTracker", () => {
  test("matches snapshot", () => {
    const wrapper = shallow(<SportTracker />);
    expect(wrapper).toMatchSnapshot();
  });
});
