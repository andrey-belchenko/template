import React from 'react';
import 'devextreme/data/odata/store';
import DataGrid, {
  Column,
  Pager,
  Paging,
  FilterRow,
  Lookup
} from 'devextreme-react/data-grid';

export default () => (
  <React.Fragment>
    <h2 className={'content-block'}>Проекты</h2>

    <DataGrid
      className={'dx-card wide-card'}
      dataSource={dataSource}
      showBorders={false}
      focusedRowEnabled={true}
      defaultFocusedRowIndex={0}
      columnAutoWidth={true}
      columnHidingEnabled={true}
    >
      <Paging defaultPageSize={10} />
      <Pager showPageSizeSelector={true} showInfo={true} />
      <FilterRow visible={true} />

      <Column dataField={'ProjectId'} width={90} hidingPriority={2} />
      <Column
        dataField={'Name'}
        width={190}
        caption={'Наименование'}
        hidingPriority={8}
      />
     
    </DataGrid>
  </React.Fragment>
);

const dataSource = {
  store: {
    version:4,
    type: 'odata',
    key: 'ProjectId',
    url: 'http://localhost:63112/odata/projects'
  },
  select: [
    'ProjectId',
    'Name'
  ]
};


