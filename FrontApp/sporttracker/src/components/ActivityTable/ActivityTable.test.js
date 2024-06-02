import React from "react";
import { shallow } from "enzyme";
import ActivityTable from "./ActivityTable";

describe("ActivityTable", () => {
  test("matches snapshot", () => {
    const wrapper = shallow(<ActivityTable />);
    expect(wrapper).toMatchSnapshot();
  });
});
