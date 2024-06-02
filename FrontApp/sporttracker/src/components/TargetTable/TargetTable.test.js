import React from "react";
import { shallow } from "enzyme";
import TargetTable from "./TargetTable";

describe("TargetTable", () => {
  test("matches snapshot", () => {
    const wrapper = shallow(<TargetTable />);
    expect(wrapper).toMatchSnapshot();
  });
});
